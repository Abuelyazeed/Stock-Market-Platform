import { ChangeEvent, SyntheticEvent, useState } from 'react';
import './App.css';
import CardList from './Components/CardList/CardList';
import Search from './Components/Search/Search';
import { CompanySearch } from './company';
import { searchCompanies } from './api';
import ListPortfolio from './Components/Portfolio/ListPortfolio/ListPortfolio';
import Navbar from './Components/Navbar/Navbar';
// import Hero from './Components/Hero/Hero';

function App() {
  const [search, setSearch] = useState<string>('');
  const [portfolioValues, setPortfolioValues] = useState<string[]>([]);
  const [searchResult, setSearchResult] = useState<CompanySearch[]>([]);
  const [serverError, setServerError] = useState<string>('');

  const handleSearchChange = (e: ChangeEvent<HTMLInputElement>) => {
    setSearch(e.target.value.toUpperCase());
  };

  const onSearchSubmit = async (e: SyntheticEvent) => {
    e.preventDefault();
    const result = await searchCompanies(search);
    if (typeof result === 'string') {
      setServerError('Failed to fetch companies. Please try again.');
    } else if (Array.isArray(result)) {
      setSearchResult(result);
    }
    console.log(searchResult);
  };

  const onStockAdd = (e: any) => {
    e.preventDefault();
    const updatedPortfolio = [...portfolioValues, e.target[0].value];
    setPortfolioValues(updatedPortfolio);
  };

  const onStockDelete = (e: any) => {
    e.preventDefault();
    const removedStock = portfolioValues.filter((value) => {
      return value != e.target[0].value;
    });
    setPortfolioValues(removedStock);
  };

  return (
    <>
      <Navbar />
      <Search
        onSearchSubmit={onSearchSubmit}
        handleSearchChange={handleSearchChange}
        search={search}
      />
      <ListPortfolio
        portfolioValues={portfolioValues}
        onStockDelete={onStockDelete}
      />
      <CardList searchResults={searchResult} onStockAdd={onStockAdd} />
      {serverError && <div>Unable to connect to API</div>}
    </>
  );
}

export default App;
