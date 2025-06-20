const API_URL = "http://localhost:5254/api/poolmember";

export async function fetchData(id) {
  const response = await fetch(`${API_URL}/${id}`);
  if (!response.ok) {
    throw new Error("Failed to fetch member items");
  }
  return response.json();
}
