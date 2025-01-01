import { ChangeEvent, SyntheticEvent, useState } from 'react';
import './App.css';
import CardList from './Components/CardList/CardList';
import Search from './Components/Search/Search';
import { CompanySearch } from './company';
import { searchCompanies } from './api';

function App() {
  const [search, setSearch] = useState<string>('');
  const [searchResult, setSearchResult] = useState<CompanySearch[]>([]);
  const [serverError, setServerError] = useState<string>('');

  const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
    setSearch(e.target.value.toUpperCase());
  };

  const onClick = async (e: SyntheticEvent) => {
    const result = await searchCompanies(search);
    if (typeof result === 'string') {
      setServerError('Failed to fetch companies. Please try again.');
    } else if (Array.isArray(result)) {
      setSearchResult(result);
    }
    console.log(searchResult);
  };

  return (
    <>
      <Search onClick={onClick} handleChange={handleChange} search={search} />
      <CardList searchResults={searchResult} />
      {serverError && <div>Unable to connect to API</div>}
    </>
  );
}

export default App;
