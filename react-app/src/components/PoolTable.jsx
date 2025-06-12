import {
  Table,
  TableHeader,
  TableCell,
  AlternateRow,
} from "../styled/PoolTable";

export default function PoolTable(props) {
  return (
    <Table>
      <TableHeader>
        <tr>
          <TableCell>Name</TableCell>
          <TableCell>Contestant</TableCell>
          <TableCell>Rank</TableCell>
          <TableCell>Points</TableCell>
        </tr>
      </TableHeader>
      <tbody>
        {Array.from(props.tableData).map((row, index) =>
          index % 2 !== 0 ? (
            <tr key={index}>
              <TableCell>{row.Name}</TableCell>
              <TableCell>{row.Contestant}</TableCell>
              <TableCell>{row.Rank}</TableCell>
              <TableCell>{row.Points}</TableCell>
            </tr>
          ) : (
            <AlternateRow key={index}>
              <TableCell>{row.Name}</TableCell>
              <TableCell>{row.Contestant}</TableCell>
              <TableCell>{row.Rank}</TableCell>
              <TableCell>{row.Points}</TableCell>
            </AlternateRow>
          )
        )}
      </tbody>
    </Table>
  );
}
