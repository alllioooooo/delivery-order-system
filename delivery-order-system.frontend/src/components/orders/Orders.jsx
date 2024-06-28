import { useState, useEffect } from "react";
import axios from "axios";
import OrderCard from "./OrderCard/OrderCard";

const Orders = () => {
  const [orderIds, setOrderIds] = useState([]);

  useEffect(() => {
    const fetchOrders = async () => {
      try {
        const response = await axios.get("http://localhost:8000/orders", {
          headers: {
            "Content-Type": "application/json",
          },
        });
        setOrderIds(response.data);
      } catch (error) {
        console.error("Error fetching orders:", error);
      }
    };

    fetchOrders();
  }, []);

  return (
    <section className="w-full overflow-scroll no-scrollbar gap-5 grid">
      {orderIds.map((orderId, indx) => (
        <OrderCard key={indx} orderId={orderId} setOrderIds={setOrderIds} />
      ))}
    </section>
  );
};

export default Orders;
