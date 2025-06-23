const API_URL = `${import.meta.env.VITE_API_URL}/pool`;

export async function fetchData(id) {
  //   const response = await fetch();
  console.log("Fetching data from Pool table at " + API_URL);
  if (id) {
    console.log(`ID sent is ${id}`);
  }
}
