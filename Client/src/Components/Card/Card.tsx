import './Card.css';

interface Props {}
function Card({}: Props) {
  return (
    <div className="card">
      <p>FinPulse</p>
      <div className="details">
        <h2>AAPL</h2>
        <p>$110</p>
      </div>
      <p className="info">
        Lorem ipsum dolor sit amet, consectetur adipisicing elit. Velit,
        numquam.
      </p>
    </div>
  );
}
export default Card;
