import { useEffect } from "react";
import { PageContainer, TableContainer } from "../styled/Home";
import {
  Table,
  TableHeader,
  TableCell,
  AlternateRow,
} from "../styled/PoolTable";
import { fetchSummaryView } from "../services/poolService";

export default function Home() {
  const username = import.meta.env.VITE_USERNAME;

  useEffect(() => {
    async function getSummary() {
      try {
        const response = await fetchSummaryView(username);
        if (response) {
          console.log(response);
        }
      } catch {
        console.error("Summary data failed to load");
      }
    }
    getSummary();
  }, []);

  return (
    <PageContainer>
      <h1>Reality Fights</h1>
      <TableContainer>
        <Table>
          <TableHeader>
            <tr>
              <TableCell
                colSpan={3}
                style={{ textAlign: "center", fontSize: "larger" }}
              >
                Totals
              </TableCell>
            </tr>
            <tr>
              <TableCell>Pool Name</TableCell>
              <TableCell>Points</TableCell>
              <TableCell>Rank</TableCell>
            </tr>
          </TableHeader>
          <tbody>
            {/* Totals Row */}
            <AlternateRow>
              <TableCell></TableCell>
              <TableCell></TableCell>
              <TableCell></TableCell>
            </AlternateRow>
            {/* Individual Pools */}
          </tbody>
        </Table>
      </TableContainer>
    </PageContainer>
  );
}
