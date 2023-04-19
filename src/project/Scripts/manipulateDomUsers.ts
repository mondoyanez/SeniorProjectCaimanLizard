export function generateHeaders(usersTableBody: JQuery<HTMLElement>): void {
    const headers: string =
        `
        <tr>
            <th>Username </th>
            <th> Email </th>
            <th> First and Last Name </th>
        </tr>
    `;
    usersTableBody.append(headers);
}

export function generateTableBody(usersTable: JQuery<HTMLElement>): void {
    const tBody: string = "<tbody id=\"user-tbody\"></tbody>";
    usersTable.append(tBody);
}