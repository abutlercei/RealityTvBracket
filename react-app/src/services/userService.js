const API_URL = import.meta.env.VITE_API_URL;

export async function fetchData(id) {
  const response = await fetch(`${API_URL}/userprofile/${id}`);
  if (!response.ok) {
    throw new Error("Failed to fetch user items");
  }
  return response.json();
}

export async function postData(userData) {
  try {
    const response = await fetch(`${API_URL}/userprofile/update`, {
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(userData),
    });
  } catch (error) {
    console.error("Error: ", error);
  }
}
