import { useEffect, useState } from "react";
import GoodsTable from "../Components/GoodsTable";

const fetchGoodsList = () => {
  return fetch("https://localhost:44308/Goods").then((res) => res.json());
};


const GoodsList = () => {
  const [goodsList, setGoodsList] = useState(null);


  useEffect(() => {
    fetchGoodsList()
      .then((goods) => { console.log("fetching GoodsList");
        setGoodsList(goods);
      })
      .catch((error) => {
        console.error("Error fetching goods list:", error);
      });
  }, []);

  if (goodsList === null) {
    return <div>Loading...</div>;
  }

  return <GoodsTable goodsList={goodsList}/>;
};

export default GoodsList;
