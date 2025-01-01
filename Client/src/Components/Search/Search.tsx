import { ChangeEvent, SyntheticEvent } from 'react';

interface Props {
  onClick: (e: SyntheticEvent) => void;
  handleChange: (e: ChangeEvent<HTMLInputElement>) => void;
  search: string | undefined;
}
const Search: React.FC<Props> = ({
  onClick,
  handleChange,
  search,
}: Props): JSX.Element => {
  return (
    <div>
      <input value={search} onChange={handleChange} />
      <button onClick={onClick}>Search</button>
    </div>
  );
};
export default Search;
