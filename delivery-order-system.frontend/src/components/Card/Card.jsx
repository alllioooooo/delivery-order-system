const Card = ({ children, url }) => {
  return (
    <section className="h-screen w-full flex justify-center items-center pt-20">
      <div className="w-4/5 h-2/3 shadow-xl rounded-lg flex overflow-hidden border">
        <div className="w-2/5 h-full">
          <img
            className="h-full w-full object-cover"
            src={url}
            alt=""
            style={{ objectFit: "cover" }}
          />
        </div>
        <div className="p-5 w-3/5 flex flex-col">{children}</div>
      </div>
    </section>
  );
};

export default Card;