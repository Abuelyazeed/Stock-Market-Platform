import { SyntheticEvent } from 'react';
import DeleteStock from '../DeleteStock/DeleteStock';

interface Props {
  portfolioValue: string;
  onStockDelete: (e: SyntheticEvent) => void;
}
const CardPortfolio = ({ portfolioValue, onStockDelete }: Props) => {
  return (
    <>
      <h4>{portfolioValue}</h4>
      <DeleteStock
        onStockDelete={onStockDelete}
        portfolioValue={portfolioValue}
      />
    </>
  );
};
export default CardPortfolio;
