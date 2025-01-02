import { SyntheticEvent } from 'react';
import DeleteStock from '../DeleteStock/DeleteStock';

interface Props {
  portfolioValue: string;
  onStockDelete: (e: SyntheticEvent) => void;
}
const CardPortfolio = ({ portfolioValue, onStockDelete }: Props) => {
  return (
    <div className="flex flex-col w-full p-8 space-y-4 text-center rounded-lg shadow-lg md:w-1/3">
      <p className="pt-6 text-xl font-bold">{portfolioValue}</p>
      <DeleteStock
        portfolioValue={portfolioValue}
        onStockDelete={onStockDelete}
      />
    </div>
  );
};
export default CardPortfolio;
