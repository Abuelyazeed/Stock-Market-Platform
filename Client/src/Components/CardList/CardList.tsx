import React, { SyntheticEvent } from 'react';
import Card from '../Card/Card';
import { CompanySearch } from '../../company';
import { v4 as uuid } from 'uuid';

interface Props {
  searchResults: CompanySearch[];
  onStockAdd: (e: SyntheticEvent) => void;
}
const CardList: React.FC<Props> = ({
  searchResults,
  onStockAdd,
}: Props): JSX.Element => {
  return (
    <>
      {searchResults.length > 0 ? (
        searchResults.map((result) => {
          return (
            <Card
              key={uuid()}
              id={result.symbol}
              searchResult={result}
              onStockAdd={onStockAdd}
            />
          );
        })
      ) : (
        <p className="mb-3 mt-3 text-xl font-semibold text-center md:text-xl">
          No results!
        </p>
      )}
    </>
  );
};
export default CardList;
