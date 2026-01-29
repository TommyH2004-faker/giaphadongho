const SearchSection = () => {
  return (
    <section className="py-3 mb-4">
      <form className="row g-2 justify-content-center align-items-center">
        <div className="col-12 col-md-4">
          <input className="form-control" placeholder="Nhập họ..." />
        </div>
        <div className="col-12 col-md-4">
          <input className="form-control" placeholder="Nhập địa phương..." />
        </div>
        <div className="col-12 col-md-2 d-grid">
          <button className="btn btn-primary" type="submit">Tìm kiếm</button>
        </div>
      </form>
    </section>
  );
};

export default SearchSection;
