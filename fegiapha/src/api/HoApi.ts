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
export async function getTop3Ho(): Promise<Ho[]> {
  const res = await fetch(`${endpointBe}/api/Ho/top3`);
  const json = await res.json();

  if (!json.isSuccess) {
    throw new Error(json.errorMessage);
  }

  return json.data as Ho[];
}
