import './Card.css';
import { CompanySearch } from '../../company';
import AddStock from '../Portfolio/AddStock/AddStock';
import { SyntheticEvent } from 'react';
import { Link } from 'react-router-dom';

interface Props {
  id: string;
  searchResult: CompanySearch;
  onStockAdd: (e: SyntheticEvent) => void;
}

const Card: React.FC<Props> = ({
  id,
  searchResult,
  onStockAdd,
}: Props): JSX.Element => {
  return (
    <div
      className="flex flex-col items-center justify-between w-full p-6 bg-slate-100 rounded-lg md:flex-row"
      key={id}
      id={id}
    >
      <Link
        to={`/company/${searchResult.symbol}`}
        className="font-bold text-center text-black  md:text-left"
      >
        {searchResult.name} ({searchResult.symbol})
      </Link>
      <p className="text-black">{searchResult.currency}</p>
      <p className="font-bold text-black">
        {searchResult.exchangeShortName} - {searchResult.stockExchange}
      </p>
      <AddStock onStockAdd={onStockAdd} symbol={searchResult.symbol} />
    </div>
  );
};
export default Card;
