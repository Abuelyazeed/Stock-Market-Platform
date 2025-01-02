import { SyntheticEvent } from 'react';

interface Props {
  onStockAdd: (e: SyntheticEvent) => void;
  symbol: string;
}
const AddStock = ({ onStockAdd, symbol }: Props) => {
  return (
    <form onSubmit={onStockAdd}>
      <input readOnly={true} hidden={true} type="text" value={symbol} />
      <button type="submit">Add</button>
    </form>
  );
};
export default AddStock;
