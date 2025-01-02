import { SyntheticEvent } from 'react';
import CardPortfolio from '../CardPortfolio/CardPortfolio';

interface Props {
  portfolioValues: string[];
  onStockDelete: (e: SyntheticEvent) => void;
}
const ListPortfolio = ({ portfolioValues, onStockDelete }: Props) => {
  return (
    <>
      <h3>My Portfolio</h3>
      <ul>
        {portfolioValues &&
          portfolioValues.map((portfolioValue) => {
            return (
              <CardPortfolio
                portfolioValue={portfolioValue}
                onStockDelete={onStockDelete}
              />
            );
          })}
      </ul>
    </>
  );
};
export default ListPortfolio;
