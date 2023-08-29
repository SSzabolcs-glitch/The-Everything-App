import React from 'react'
import ReactDOM from 'react-dom/client'
import { createBrowserRouter, RouterProvider } from "react-router-dom";

import Layout from "./Pages/Layout";
import './index.css'
import GoodsList from './Pages/GoodsList'
import CustomerList from './Pages/CustomerList'
import HomePage from './Pages/HomePage';
import SignUp from './Pages/SignUp';
import LogIn from './Pages/LogIn';

const router = createBrowserRouter([
  {
    path: "/",
    element: <Layout />,
    //errorElement: <ErrorPage />,
    children: [
      {
        path: "/",
        element: <HomePage />,
      },
      {
        path: "/signup",
        element: <SignUp />,
      },
      {
        path: "/login",
        element: <LogIn />,
      },
      {
        path: "/customerlist",
        element: <CustomerList />,
      },
      {
        path: "/goodslist",
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
