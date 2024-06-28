
import Navbar from "../components/navbar/Navbar";
import Orders from "../components/orders/Orders";
import Card from "../components/Card/Card";

const AllOrders = () => {
  return (
    <div>
      <Navbar />
      <Card
        url={
          "https://img.freepik.com/free-photo/delivery-male-with-packages_23-2148869422.jpg"
        }
      >
        <Orders />
      </Card>
    </div>
  );
};

export default AllOrders;
