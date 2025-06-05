import {
  Table,
  TableHeader,
  TableCell,
  AlternateRow,
} from "../styled/PoolTable";

export default function PoolTable() {
  const tableData = [
    { rank: 1, poolMem: "Rosalind", contestant: "Richard", points: 15 },
    { rank: 2, poolMem: "Jeff", contestant: "Kelly", points: 14 },
    { rank: 3, poolMem: "Cecile", contestant: "Rudy", points: 13 },
    { rank: 4, poolMem: "Nina", contestant: "Susan", points: 12 },
    { rank: 5, poolMem: "Patrica", contestant: "Sean", points: 11 },
    { rank: 6, poolMem: "Kelley", contestant: "Coleen", points: 10 },
    { rank: 7, poolMem: "Jayden", contestant: "Gervase", points: 9 },
    { rank: 8, poolMem: "Taylor", contestant: "Jenna", points: 8 },
    { rank: 9, poolMem: "Paris", contestant: "Greg", points: 7 },
    { rank: 10, poolMem: "Kathleen", contestant: "Gretchen", points: 6 },
    { rank: 11, poolMem: "Adam", contestant: "Joel", points: 5 },
    { rank: 12, poolMem: "Stephan", contestant: "Dirk", points: 4 },
    { rank: 13, poolMem: "Francis", contestant: "Ramona", points: 3 },
    { rank: 14, poolMem: "April", contestant: "Stacey", points: 2 },
    { rank: 15, poolMem: "Lucy", contestant: "BB", points: 1 },
    { rank: 16, poolMem: "Morgan", contestant: "Sonja", points: 0 },
  ];

  return (
    <Table>
      <TableHeader>
        <tr>
          <TableCell>Rank</TableCell>
          <TableCell>Pool Member</TableCell>
          <TableCell>Contestant</TableCell>
          <TableCell>Points</TableCell>
        </tr>
      </TableHeader>
      <tbody>
        {tableData.map((row) =>
          row.rank % 2 === 0 ? (
            <tr key={row.rank}>
              <TableCell>{row.rank}</TableCell>
              <TableCell>{row.poolMem}</TableCell>
              <TableCell>{row.contestant}</TableCell>
              <TableCell>{row.points}</TableCell>
            </tr>
          ) : (
            <AlternateRow key={row.rank}>
              <TableCell>{row.rank}</TableCell>
              <TableCell>{row.poolMem}</TableCell>
              <TableCell>{row.contestant}</TableCell>
              <TableCell>{row.points}</TableCell>
            </AlternateRow>
          )
        )}
      </tbody>
    </Table>
  );
}
