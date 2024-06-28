import { useState } from "react";
import axios from "axios";

import { format } from "date-fns";
import { ru } from "date-fns/locale";

const OrderCard = ({ orderId, setOrderIds }) => {
  const [orderDetails, setOrderDetails] = useState({});

  const handleFetchOrderDetails = async (orderId) => {
    try {
      const response = await axios.get(
        `http://localhost:8000/orders/${orderId}`,
        {
          headers: {
            "Content-Type": "application/json",
          },
        }
      );
      setOrderDetails((prevDetails) => ({
        ...prevDetails,
        [orderId]: response.data,
      }));
    } catch (error) {
      console.error(`Error fetching order ${orderId} details:`, error);
    }
  };

  const handleClose = (orderId) => {
    setOrderDetails((prevDetails) => {
      const updatedDetails = { ...prevDetails };
      delete updatedDetails[orderId];
      return updatedDetails;
    });
  };

  const handleDeleteOrder = async (orderId) => {
    try {
      await axios.delete(`http://localhost:8000/orders/${orderId}`, {
        headers: {
          "Content-Type": "application/json",
        },
      });
      setOrderDetails((prevDetails) => {
        const updatedDetails = { ...prevDetails };
        delete updatedDetails[orderId];
        return updatedDetails;
      });
      setOrderIds((prevIds) => prevIds.filter((id) => id !== orderId));
    } catch (error) {
      console.error(`Error deleting order ${orderId}:`, error);
    }
  };

  const formatDate = (dateString) => {
    const date = new Date(dateString);
    return format(date, "d MMMM yyyy", { locale: ru });
  };

  return (
    <>
      <div className="border p-4 rounded-lg">
        <p>
          <strong>Номер заказа: </strong>
          {orderId}
        </p>
        {!orderDetails[orderId] && (
          <div
            className="flex justify-end"
            onClick={() => handleFetchOrderDetails(orderId)}
          >
            <svg
              xmlns="http://www.w3.org/2000/svg"
              fill="none"
              viewBox="0 0 24 24"
              stroke-width="1.5"
              stroke="currentColor"
              className="size-6 cursor-pointer"
            >
              <path
                stroke-linecap="round"
                stroke-linejoin="round"
                d="m19.5 8.25-7.5 7.5-7.5-7.5"
              />
            </svg>
          </div>
        )}
        {orderDetails[orderId] && (
          <>
            <div
              className="flex justify-end"
              onClick={() => handleClose(orderId)}
            >
              <svg
                xmlns="http://www.w3.org/2000/svg"
                fill="none"
                viewBox="0 0 24 24"
                stroke-width="1.5"
                stroke="currentColor"
                className="size-6 cursor-pointer rotate-180"
              >
                <path
                  stroke-linecap="round"
                  stroke-linejoin="round"
                  d="m19.5 8.25-7.5 7.5-7.5-7.5"
                />
              </svg>
            </div>
            <div className="mt-4">
              <p>
                <strong>Город отправки:</strong>{" "}
                {orderDetails[orderId].senderCity}
              </p>
              <p>
                <strong>Адрес отправки:</strong>{" "}
                {orderDetails[orderId].senderAddress}
              </p>
              <p>
                <strong>Город куда отправить:</strong>{" "}
                {orderDetails[orderId].receiverCity}
              </p>
              <p>
                <strong>Адрес куда отправить:</strong>{" "}
                {orderDetails[orderId].receiverAddress}
              </p>
              <p>
                <strong>Вес:</strong> {orderDetails[orderId].weight} кг.
              </p>
              <p>
                <strong>Дата:</strong>{" "}
                {formatDate(orderDetails[orderId].pickupDate)}
              </p>
            </div>
            <div
              className="flex justify-end"
              onClick={() => handleDeleteOrder(orderId)}
            >
              <svg
                xmlns="http://www.w3.org/2000/svg"
                fill="none"
                viewBox="0 0 24 24"
                strokeWidth={1.5}
                stroke="currentColor"
                className="size-6 cursor-pointer"
              >
                <path
                  strokeLinecap="round"
                  strokeLinejoin="round"
                  d="m14.74 9-.346 9m-4.788 0L9.26 9m9.968-3.21c.342.052.682.107 1.022.166m-1.022-.165L18.16 19.673a2.25 2.25 0 0 1-2.244 2.077H8.084a2.25 2.25 0 0 1-2.244-2.077L4.772 5.79m14.456 0a48.108 48.108 0 0 0-3.478-.397m-12 .562c.34-.059.68-.114 1.022-.165m0 0a48.11 48.11 0 0 1 3.478-.397m7.5 0v-.916c0-1.18-.91-2.164-2.09-2.201a51.964 51.964 0 0 0-3.32 0c-1.18.037-2.09 1.022-2.09 2.201v.916m7.5 0a48.667 48.667 0 0 0-7.5 0"
                />
              </svg>
            </div>
          </>
        )}
      </div>
    </>
  );
};

export default OrderCard;
