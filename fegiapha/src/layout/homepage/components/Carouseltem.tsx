import React from "react";
import type { Ho } from "../../../model/entities";

interface Props {
  ho: Ho;
}

const CarouselItemHo: React.FC<Props> = ({ ho }) => {
  return (
    <div className="col-md-4 text-center">
      <img
        src={ho.hinhAnh}
        alt={ho.tenHo}
        style={{
          width: "100%",
          height: "160px",
          objectFit: "cover",
          borderRadius: "8px",
        }}
      />
      <h5 className="mt-2">{ho.tenHo}</h5>
      <p>{ho.moTa}</p>
    </div>
  );
};

export default CarouselItemHo;
