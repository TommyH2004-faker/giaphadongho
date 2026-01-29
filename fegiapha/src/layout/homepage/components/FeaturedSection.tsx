
const featuredData = [
  {
    img: "https://lh3.googleusercontent.com/aida-public/AB6AXuAyqKW81m9ZTO33VrDPQBtRtOtl1v24zXEyBWj46GKcQcu04gNhPf9CcVolH5RPjULFxmXOUnIPyIYSs5edQg1zMoVgvddXaQrmwrKZX_qDoqNcQ4642BuO_3P0K69-6ldSl2ugRu5DY0uFfPfiH2efyt0-_aAvgxuWGLBvviXt_Afs1pEkkFMVGihyFIlOpxvDQlLQsv30kvCOQ-fXRUiLwpnXDmz8Ski5EFZ3ZpwlQ7xMscYtEAC2EGAeFaoEu2u-q7VUx69SaCjU",
    location: "Ninh Bình",
    title: "Nhà Thờ Họ Nguyễn Đại Tộc",
    desc: "Kiến trúc gỗ lim 5 gian 2 chái, xây dựng từ thời Hậu Lê với những đường nét chạm khắc tinh xảo."
  },
  {
    img: "https://lh3.googleusercontent.com/aida-public/AB6AXuDyP7fH2aWfQyg-kGU8XUg2G5J7iP9L-qRxJN7Vu4i7dkSqO7K0LoIpBvWXgL4ealK82Cvts0emQPGnXtRsTODKgt5r9IkICLWlDY0q0aii31g5OaCrIp52a-Bfkxvve8igKjOPOvyfi1cB6q4Zphc-rRbwd7XG8mGVEXfbIv0BryDP11fdZ8uitH2cRvF04RngMhAE4vafCEVIDgvqmXkgzU6Jdj2vNOS2DcZgBzzHaZJPxYOxVkVvFjERALvHXKUXBpn9HESfS_w2",
    location: "Hà Nam",
    title: "Từ Đường Họ Trần",
    desc: "Nơi lưu giữ sắc phong và bộ gia phả bằng chữ Hán cổ có niên đại hơn 300 năm."
  },
  {
    img: "https://lh3.googleusercontent.com/aida-public/AB6AXuAgDN3H0pxB-blHL3sNpP68oSJpAei41cYsO3udDxk9HUTlzKfDeBvIOC-Ox3kfmJusLbBn0fGPIIkO3wa3zaOPMHiLzkUIBabWA4Cy7EuLYXubdfGmmrKESHshpH9bZjlFLkzSe8NbnNQYJR4HCL0nk-4u8RyD_1w9TKIIZ-u1KCO8o8QwknHCDlijlJe3oKcEERf2f-nnKnoToYaYoEEIwLTSTGR5NSu1I5VkDuCE69vdRWaoGYseCqCAU174ANqDCsfJPyFLvZiv",
    location: "Huế",
    title: "Phủ Thờ Vĩnh Quốc Công",
    desc: "Mang đậm dấu ấn kiến trúc cung đình Huế với hệ thống xà gồ sơn son thếp vàng."
  }
];

const FeaturedSection = () => {
  return (
    <section className="py-5 px-2 px-md-4 mb-4 bg-white rounded-4 shadow-lg">
      <div className="d-flex flex-column flex-md-row justify-content-between align-items-end mb-4 gap-3">
        <div>
          <span className="text-warning fw-bold text-uppercase small mb-2 d-block font-serif" style={{letterSpacing: '.2em'}}>Kiến Trúc & Di Sản</span>
          <h2 className="fw-bold mb-0 text-dark display-6 font-serif">Nhà Thờ Tổ Tiêu Biểu</h2>
        </div>
        <a href="#" className="text-warning text-decoration-none fw-bold text-uppercase small border-bottom border-warning pb-1 align-self-md-end align-self-center font-sans" style={{letterSpacing: '.15em'}}>Xem tất cả di sản &rarr;</a>
      </div>
      <div className="row g-4">
        {featuredData.map((item, idx) => (
          <div className="col-12 col-md-4" key={idx}>
            <div className="card h-100 border-0 bg-light position-relative overflow-hidden shadow group rounded-4">
              <div className="position-relative rounded-4 overflow-hidden" style={{aspectRatio: '4/5', background: '#eee'}}>
                <img src={item.img} alt={item.title} className="w-100 h-100 object-fit-cover rounded-4 transition-all" style={{objectFit: 'cover', borderRadius: '1.5rem', filter: 'grayscale(0.2)', transition: 'filter .5s, transform .5s'}} onMouseOver={e => e.currentTarget.style.filter = 'grayscale(0)'} onMouseOut={e => e.currentTarget.style.filter = 'grayscale(0.2)'} />
                <div className="position-absolute top-0 start-0 w-100 h-100 rounded-4" style={{background: 'linear-gradient(to top, #2C1D13 80%, transparent 100%)', opacity: 0.7}}></div>
              </div>
              <div className="position-absolute bottom-0 start-0 w-100 p-4" style={{zIndex: 2}}>
                <div className="d-flex align-items-center gap-2 text-warning mb-2 font-sans">
                  <span className="material-symbols-outlined align-middle" style={{fontSize: 18}}>location_on</span>
                  <span className="small fw-bold text-uppercase" style={{letterSpacing: '.15em'}}>{item.location}</span>
                </div>
                <h3 className="h5 text-dark fw-bold mb-2 font-serif">{item.title}</h3>
                <p className="text-secondary small mb-3 font-sans" style={{opacity: 0.9}}>{item.desc}</p>
                <button className="btn btn-warning btn-sm px-4 fw-bold text-uppercase font-sans shadow-sm">Chi Tiết</button>
              </div>
            </div>
          </div>
        ))}
      </div>
    </section>
  );
};

export default FeaturedSection;
