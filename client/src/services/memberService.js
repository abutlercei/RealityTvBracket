const API_URL = `${import.meta.env.VITE_API_URL}/poolmember`;

export async function fetchData(id) {
  const response = await fetch(`${API_URL}/${id}`);
  if (!response.ok) {
    throw new Error("Failed to fetch member items");
  }
  return response.json();
}
