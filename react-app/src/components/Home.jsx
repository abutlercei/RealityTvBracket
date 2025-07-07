import { useEffect, useState } from "react";
import { PageContainer, TableContainer, SingleCellRow } from "../styled/Home";
import {
  Table,
  TableHeader,
  TableCell,
  AlternateRow,
} from "../styled/PoolTable";
import { fetchSummaryView } from "../services/poolService";

export default function Home() {
  const username = import.meta.env.VITE_USERNAME;

  const [totals, setTotals] = useState({
    singleContestantPoints: 0,
    singleContestantAverageRank: 0.0,
    bracketPoints: 0,
    bracketTotalAccuracy: "0 / 0",
  });

  useEffect(() => {
    async function getSummary() {
      try {
        const response = await fetchSummaryView(username);
        if (response) {
          setTotals(response);
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
              <SingleCellRow colSpan={3}>Totals</SingleCellRow>
            </tr>
            <tr>
              <TableCell>Pool Type</TableCell>
              <TableCell>Points</TableCell>
              <TableCell>Rank</TableCell>
            </tr>
          </TableHeader>
          <tbody>
            {/* Totals Rows */}
            <AlternateRow>
              <TableCell>Single Contestant</TableCell>
              <TableCell>{totals["singleContestantPoints"]}</TableCell>
              <TableCell>
                {new Intl.NumberFormat("en-US", {
                  style: "decimal",
                  maximumFractionDigits: 2,
                }).format(totals["singleContestantAverageRank"])}
              </TableCell>
            </AlternateRow>
            <AlternateRow>
              <TableCell>Bracket</TableCell>
              <TableCell>{totals["bracketPoints"]}</TableCell>
              <TableCell>{totals["bracketTotalAccuracy"]}</TableCell>
            </AlternateRow>
            {/* Individual Pools */}
            <tr>
              <SingleCellRow colSpan={3}>Pools</SingleCellRow>
            </tr>
          </tbody>
        </Table>
      </TableContainer>
    </PageContainer>
  );
}
