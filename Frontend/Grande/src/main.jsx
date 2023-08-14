import React from 'react'
import ReactDOM from 'react-dom/client'
import './index.css'
import GoodsList from './Pages/GoodsList.jsx'
import CustomerList from './Pages/CustomerList'

ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
    <CustomerList />
    <GoodsList />
  </React.StrictMode>,
)
