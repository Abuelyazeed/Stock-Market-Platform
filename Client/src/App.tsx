import { ChangeEvent, SyntheticEvent, useState } from 'react';
import './App.css';
import CardList from './Components/CardList/CardList';
import Search from './Components/Search/Search';

function App() {
  const [search, setSearch] = useState<string>('');

  const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
    setSearch(e.target.value);
    console.log(e.target.value);
  };

  const onClick = (e: SyntheticEvent) => {
    console.log(e);
  };

  return (
    <>
      <Search onClick={onClick} handleChange={handleChange} search={search} />
      <CardList />
    </>
  );
}

export default App;
