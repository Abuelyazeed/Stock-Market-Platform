import { ChangeEvent, SyntheticEvent, useState } from 'react';

type Props = {};
const Search: React.FC<Props> = (props: Props): JSX.Element => {
  const [search, setSearch] = useState<string>('');

  const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
    setSearch(e.target.value);
    console.log(e.target.value);
  };

  const onClick = (e: SyntheticEvent) => {
    console.log(e);
  };

  return (
    <div>
      <input value={search} onChange={handleChange} />
      <button onClick={onClick}>Search</button>
    </div>
  );
};
export default Search;
