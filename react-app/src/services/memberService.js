const API_URL = import.meta.env.VITE_API_URL;

export async function fetchData(id) {
  const response = await fetch(`${API_URL}/poolmember/${id}`);
  if (!response.ok) {
    throw new Error("Failed to fetch member items");
  }
  return response.json();
}
