import { SyntheticEvent } from 'react';

interface Props {
  onStockDelete: (e: SyntheticEvent) => void;
  portfolioValue: string;
}
const DeleteStock = ({ onStockDelete, portfolioValue }: Props) => {
  return (
    <div>
      <form onSubmit={onStockDelete}>
        <input
          readOnly={true}
          hidden={true}
          type="text"
          value={portfolioValue}
        />
        <button>X</button>
      </form>
    </div>
  );
};
export default DeleteStock;
