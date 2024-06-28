import "./index.css";
import "./output.css";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import AllOrders from "./pages/AllOrders";
import CreateOrder from "./pages/CreateOrder";
import OrderDetails from "./pages/OrderDetails";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<CreateOrder />} />
        <Route path="/all" element={<AllOrders />} />
        <Route path="/:id" element={<OrderDetails />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
