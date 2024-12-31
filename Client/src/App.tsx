import { useState } from 'react';
import './App.css';
import CardList from './Components/CardList/CardList';
import Search from './Components/Search/Search';

function App() {
  const [count, setCount] = useState(0);

  return (
    <>
      <Search />
      <CardList />
    </>
  );
}

export default App;
