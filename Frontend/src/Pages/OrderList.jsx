import { useEffect, useState } from 'react';
import { useContext } from 'react';
import { UserContext } from '../main.jsx';
import OrderTable from "../Components/OrderTable/OrderTable.jsx";
const url = process.env.VITE_APP_MY_URL;

/*
const updateOrder = (updatedorder, email, user) => {
  console.log(email)
  console.log("ORDER UPDATE - PUT REQUEST")

  return fetch(`${url}/api/UpdateUser?email=${encodeURIComponent(email)}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
      'Authorization': 'Bearer ' + user.token
    },
    body: JSON.stringify(updatedcustomer),
  })
  .then(data => {
    console.log('Customer updated successfully:', data);
  })
  .catch(error => {
    console.error('Error updating customer:', error);
    throw error;
  });
};

const deleteCustomer = (email, user) => {
  console.log(email),
  console.log(user.userName, user.token),
  console.log("CUSTOMER DELETE")
  return fetch(`${url}/api/DeleteUser?email=${encodeURIComponent(email)}`, {
    method: "DELETE",
      headers: {
      'Authorization': 'Bearer ' + user.token
    },
  });
};
*/

function OrderList() {
  const [orders, setOrders] = useState([]);
  const { user, setUser, login, logout } = useContext(UserContext);

  useEffect(() => {
    fetch(`${url}/api/GetOrders`, //change it to URL!
    {
      method: 'GET',
      headers: {
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + user.token //the space is necessary after "Bearer"
      },
    })
      .then(response => response.json()) // Parse the response as JSON
      .then(data => setOrders(data)) // Update the state with the parsed data
      .catch(error => console.error(error));
  }, [user.token]);
  
/*
  const handleUpdate = (newUsername, email) => {
    console.log(email);
    console.log(newUsername["customer-username"]);
    console.log("handleUpdate");

    let updatedCustomer = customers.find(c=> c.email === email);
    updatedCustomer.userName = newUsername["customer-username"];

    console.log(updatedCustomer);

    updateCustomer(updatedCustomer, email, user)
    .then(() => {
      //after a successful update, updating the local state as well
      setCustomers(prevCustomers => {
        const updatedCustomers = prevCustomers.map(c => {
          if (c.email === email) {
            return { ...c, userName: newUsername["customer-username"] };
          }
          return c;
        });
        return updatedCustomers;
      });
    });
  };

  const handleDelete = (email) => {
    console.log(email)
    console.log("handleDelete")
    deleteCustomer(email, user)
    .then(() => {
      //after a successful delete, updating the local state
      setCustomers(prevCustomers => prevCustomers.filter(c => c.email !== email));
    });
}
*/
  return (
    <div>
      <>
      <OrderTable 
      orders={orders}
      />
      </>
    </div>
  );
}

export default OrderList;