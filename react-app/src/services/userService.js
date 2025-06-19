const API_URL = "http://localhost:5254/api/userprofile";

export async function fetchData(id) {
  const response = await fetch(`${API_URL}/${id}`);
  if (!response.ok) {
    throw new Error("Failed to fetch user items");
  }
  return response.json();
}

export async function postData(userData) {
  try {
    const response = await fetch(`${API_URL}/update`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(userData),
    });
  } catch (error) {
    console.error("Error: ", error);
  }
}
