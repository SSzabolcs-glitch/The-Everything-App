import React from 'react'
import ReactDOM from 'react-dom/client'
import { createBrowserRouter, RouterProvider } from "react-router-dom";

import Layout from "./Pages/Layout";
import './index.css'
import GoodsList from './Pages/GoodsList.jsx'
import CustomerList from './Pages/CustomerList'

const router = createBrowserRouter([
  {
    path: "/",
    element: <Layout />,
    //errorElement: <ErrorPage />,
    children: [
      {
        path: "/",
        element: <CustomerList />,
      },
      {
        path: "/",
        element: <GoodsList />,
      },
    ],
  },
]);


const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>,
);
