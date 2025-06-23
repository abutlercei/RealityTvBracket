const API_URL = import.meta.env.VITE_API_URL;

export async function fetchData(id) {
  console.log("Fetching data from Pool table");
  if (id) {
    console.log(`ID sent is ${id}`);
  }
}
