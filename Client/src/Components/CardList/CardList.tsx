import React from 'react';
import Card from '../Card/Card';

interface Props {}
const CardList: React.FC<Props> = ({}: Props): JSX.Element => {
  return (
    <div>
      <Card companyName={'Apple'} ticker={'AAPL'} price={100} />
      <Card companyName={'Microsoft'} ticker={'AAPL'} price={100} />
      <Card companyName={'Apple'} ticker={'AAPL'} price={100} />
    </div>
  );
};
export default CardList;
