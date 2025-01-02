import './Card.css';
import { CompanySearch } from '../../company';
import AddStock from '../Portfolio/AddStock/AddStock';
import { SyntheticEvent } from 'react';

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
    <div key={id} id={id} className="card">
      <img alt="company logo" />
      <div className="details">
        <h2>
          {searchResult.name} ({searchResult.symbol})
        </h2>
        <p>{searchResult.currency}</p>
      </div>
      <p className="info">
        {searchResult.exchangeShortName} - {searchResult.stockExchange}
      </p>
      <AddStock onStockAdd={onStockAdd} symbol={searchResult.symbol} />
    </div>
  );
};
export default Card;
