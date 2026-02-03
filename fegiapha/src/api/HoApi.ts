import type { Ho } from "../model/entities";
import { endpointBe } from "../utils/contant";

export default function getAllHo(): Promise<Ho[]> {
  return fetch(`${endpointBe}/api/Ho`)
    .then((res) => {
      if (!res.ok) {
        throw new Error("Lỗi khi lấy danh sách Họ");
      }
      return res.json();
    })
    .then((result) => {
      if (!result.isSuccess) {
        throw new Error(result.errorMessage || "Lấy dữ liệu thất bại");
      }
      return result.data as Ho[];
    });
}
