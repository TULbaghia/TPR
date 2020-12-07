<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:tpr="http://p.lodz.pl">
	<xsl:template match="/">
		<html>
			<head>
				<style>
					table {border-collapse: collapse;}
					td, th {padding: 5px;}
				</style>
			</head>
			<body>
				<h2>Mój katalog samochodów</h2>
				<table border="1">
					<tr bgcolor="#9acd32">
						<th>Model</th>
						<th>Marka</th>
						<th>RokProdukcji</th>
						<th>Przebieg</th>
						<th>Cena</th>
					</tr>
					<xsl:for-each select="tpr:Katalog/tpr:Samochod">
						<tr>
							<td>
								<xsl:value-of select="tpr:Marka"/>
							</td>
							<td>
								<xsl:value-of select="tpr:Model"/>
							</td>
							<td>
								<xsl:value-of select="tpr:RokProdukcji"/>
							</td>
							<td>
								<xsl:value-of select="tpr:Przebieg"/>
							</td>
							<td>
								<xsl:value-of select="tpr:Cena"/>
							</td>
						</tr>
					</xsl:for-each>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
