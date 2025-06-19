// May need to change based on computer settings
const API_URL = "http://localhost:5254/api/data";

export async function fetchData(queryType, searchValue) {
  const response = await fetch(
    `${API_URL}?queryType=${queryType}&&searchValue=${searchValue}`
  );
  if (!response.ok) {
    throw new Error("Failed to fetch items");
  }

  if (queryType === "updateUser") {
    return;
  }
  return response.json();
}
