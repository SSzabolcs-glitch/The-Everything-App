
import PropTypes from "prop-types";

const GoodsTable = ({ goodsList }) => (
  <div className="GoodsTable">
    <table>
      <thead>
        <tr>
          <th>Item ID</th>
          <th>Product name</th>
          <th>Unit price</th>
          <th>Inventory</th>
          <th />
        </tr>
      </thead>
      <tbody>
        {goodsList.map((good) => (
          <tr key={good.itemId}>
            <td>{good.itemId}</td>
            <td>{good.productName}</td>
            <td>{good.unitPrice}</td>
            <td>{good.inventory}</td>
          </tr>
        ))}
      </tbody>
    </table>
  </div>
);

// Add PropTypes validation for the `goodsList` prop
// (Specifies the types of props that a component should receive, it's generally considered good practice.
// PropTypes help catch type-related bugs early and make it clear what props a component expects)
GoodsTable.propTypes = {
  goodsList: PropTypes.arrayOf(
    PropTypes.shape({
      itemId: PropTypes.number.isRequired,
      productName: PropTypes.string.isRequired,
      unitPrice: PropTypes.number.isRequired,
      inventory: PropTypes.number.isRequired,
    })
  ).isRequired,
};

export default GoodsTable;