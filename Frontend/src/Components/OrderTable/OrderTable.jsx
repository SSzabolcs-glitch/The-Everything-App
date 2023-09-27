import "./OrderTable.css";
import PropTypes from 'prop-types';

const OrderTable = ({ orders, onDelete, onUpdate }) => {
/*
  const onSubmit = async(e, email) => {
    e.preventDefault();
    console.log(e)
    console.log(e.target)

    const formData = new FormData(e.target);

    /*
    const entries = [...formData.entries()];

    const updatedCustomer = entries.reduce((acc, entry) => {
      const [k, v] = entry;
      acc[k] = v;
      return acc;
    }, {});*/
/*
    const updatedCustomer = {};

    for (let [key, value] of formData.entries()) {
    updatedCustomer[key] = value;
    }

    return onUpdate(updatedCustomer, email);
  };
*/
  return (
    <>
      <div className="order-list">
        <div className="order-list-title">ORDER LIST</div>
      </div>

      <div className="order-list-table">

        <table>
          <thead>
            <tr>
              <th className="th-order-id">Order Id</th>
              <th className="th-order-user-id">User Id</th>
              <th className="th-order-total-price">Total Price</th>
              <th className="th-order-shipping-address-id">Shipping Address Id</th>
            </tr>
          </thead>
        </table>

        <div className="order-list-table-data">
          {orders && orders.map((order) => (
            
              <table key={order.id}>
                <tbody>

                    <tr key={order.id}>
                    <td className="order-id">{order.id}</td>
                    <td className="order-user-id">{order.userId}</td>
                    <td className="order-total-price">{order.totalPrice}</td>
                    <td className="order-shipping-address-id">{order.shippingAddressId}</td>
                  </tr>

                </tbody>
              </table>
            
          ))}</div>
      </div>
    </>
  );
};

OrderTable.propTypes = {
    orders: PropTypes.array.isRequired
};

export default OrderTable;