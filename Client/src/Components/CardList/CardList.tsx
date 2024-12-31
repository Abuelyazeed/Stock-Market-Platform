import Card from '../Card/Card';

interface Props {}
function CardList({}: Props) {
  return (
    <div>
      <Card companyName={'Apple'} ticker={'AAPL'} price={100} />
      <Card companyName={'Microsoft'} ticker={'AAPL'} price={100} />
      <Card companyName={'Apple'} ticker={'AAPL'} price={100} />
    </div>
  );
}
export default CardList;
