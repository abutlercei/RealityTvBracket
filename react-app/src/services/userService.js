const API_URL = `${import.meta.env.VITE_API_URL}/userprofile`;

export async function fetchData(id) {
  const response = await fetch(`${API_URL}/${id}`);
  if (!response.ok) {
    throw new Error("Failed to fetch user items");
  }
  return response.json();
}

export async function findUser(formData) {
  const resonse = await fetch(`${API_URL}/login`, {
    method: "POST",
    body: formData,
  });

  const result = await resonse.json();
  if (result.status == 401) {
    return false;
  }
  return true;
}

export async function postData(userData) {
  try {
    const response = await fetch(`${API_URL}/update`, {
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
