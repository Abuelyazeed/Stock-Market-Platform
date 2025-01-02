import { SyntheticEvent } from 'react';

interface Props {
  onStockDelete: (e: SyntheticEvent) => void;
  portfolioValue: string;
}
const DeleteStock = ({ onStockDelete, portfolioValue }: Props) => {
  return (
    <div>
      <form onSubmit={onStockDelete}>
        <input hidden={true} value={portfolioValue} />
        <button className="block w-full py-3 text-white duration-200 border-2 rounded-lg bg-red-500 hover:text-red-500 hover:bg-white border-red-500">
          Remove Stock
        </button>
      </form>
    </div>
  );
};
export default DeleteStock;
