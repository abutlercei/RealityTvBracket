// May need to change based on computer settings
const API_URL = "http://localhost:5254/api/data";

export async function fetchData(queryType) {
  const response = await fetch(`${API_URL}?queryType=${queryType}`);
  if (!response.ok) {
    throw new Error("Failed to fetch items");
  }
  return await response.json();
}
