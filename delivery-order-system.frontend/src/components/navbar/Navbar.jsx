import { NavLink } from "react-router-dom";

const Navbar = () => {
  return (
    <nav className="fixed w-full h-24 flex items-center shadow-md justify-between">
      <h2 className="p-5 text-2xl">Delivery Order System</h2>
      <section className="flex items-center justify-center p-5">
        <div>
          <NavLink to="/">
            <p className="text-xl m-5 p-2 bg-white rounded-lg shadow-sm hover:shadow-md hover:bg-slate-100">
              Создать заказ
            </p>
          </NavLink>
        </div>
        <div>
          <NavLink to="/all">
            <p className="text-xl m-5 p-2 bg-white rounded-lg shadow-sm hover:shadow-md hover:bg-slate-100">
              Все заказы
            </p>
          </NavLink>
        </div>
      </section>
    </nav>
  );
};

export default Navbar;
