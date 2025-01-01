import React from 'react';
import Card from '../Card/Card';
import { CompanySearch } from '../../company';
import { v4 as uuid } from 'uuid';

interface Props {
  searchResults: CompanySearch[];
}
const CardList: React.FC<Props> = ({ searchResults }: Props): JSX.Element => {
  return (
    <>
      {searchResults.length > 0 ? (
        searchResults.map((result) => {
          return <Card key={uuid()} id={result.symbol} searchResult={result} />;
        })
      ) : (
        <h1>No results</h1>
      )}
    </>
  );
};
export default CardList;
