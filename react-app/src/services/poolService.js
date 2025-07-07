const API_URL = `${import.meta.env.VITE_API_URL}/pool`;

export async function fetchData(id) {
  const response = await fetch(`${API_URL}/${id}`);
  if (!response.ok) {
    throw new Error("Failed to find and fetch pool item");
  }
  return response.json();
}

export async function fetchSummaryView(id) {
  const response = await fetch(`${API_URL}/summary/${id}`);
  if (!response.ok) {
    throw new Error("Failed to find summary for user");
  }
  return response.json();
}

export async function fetchAllData() {
  const response = await fetch(`${API_URL}/all`);
  if (!response.ok) {
    throw new Error("Failed to fetch all pool items");
  }
  return response.json();
}
