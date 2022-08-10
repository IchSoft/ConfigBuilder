# Testprojekt "ConfigEditor" für Probearbeiten

## Beschreibung 

Der "Config-Editor" soll ein Tool sein, mit dem Anwender ohne XML-Kenntnisse eine Config-Datei anlegen und bearbeiten können. Diese Config-Datei wird als XML gespeichert. Über eine UI kann man dann Änderungen vornehmen, ohne Gefahr zu laufen, die XML zu "beschädigen".

## Arbeits- und Hilfsmittel

- IDE nach Belieben
- Jegliche Art der Recherche (StackOverflow, etc.)
- Jederzeit Fragen stellen

## Anforderung

- Der Code wird in einem git Repository versioniert (Plattform frei wählbar, muss zugänglich sein)
- Der "Config-Editor" wird als C# Applikation implementiert (Runtime frei wählbar)
- Es kann eine neue Config angelegt werden
- Es kann eine bestehende Config geöffnet werden
- Die Config wird grafisch in der UI dargestellt
- Es können Server hinzugefügt werden
- Es können Server bearbeitet werden
- Es können Server entfernt werden
- Es können Clients hinzugefügt werden
- Es können Clients bearbeitet werden
- Es können Clients entfernt werden
- ConnectionStrings können als Vorlage separat gespeichert werden
- Die Logik wird über Unit Tests abgesichert

## XML-Struktur

- Die Config-XML besitzt ein "Config" Root-Node
- "Config" beinhaltet ein "Servers" Node
- "Servers" beinhaltet 0-n "Server" Nodes
- "Server" beinhaltet ein "path" Attribut
- "Server" beinhalten ein "ConnectionString" Node
- "ConnectionString" beinhaltet einen String Value
- "Config" beinhaltet ein "Clients" Node
- "Clients" beinhaltet 0-n "Client" Nodes
- "Client" beinhaltet ein "path" Attribut
- "Client" beinhalten ein "TSClient" Node
- "TSClient" beinhaltet einen Boolean Value

##Bonus
- Von dem Benutzer frei Definierbare/Konfigurierbare Sub-Nodes im Server wie auch im Client Node.

## Leere Config


``` xml
<?xml version="1.0" encoding="utf-8"?>
<Config>
  <Servers>
  </Servers>
  <Clients>
  </Clients>
</Config>
```

## Beispiel-Config

``` xml
<?xml version="1.0" encoding="utf-8"?>
<Config>
  <Servers>
	<Server path="c:\program files (x86)\werbas\werbasweb\server">
	  <ConnectionString>Initial Catalog=WWFirmen;Data Source=.\WERBASWEB;</ConnectionString>
	</Server>
	<Server path="c:\program files (x86)\werbas\werbasweb\serverNightly">
	  <ConnectionString>Initial Catalog=WWFirmen_Nightly;Data Source=.\WERBASWEB;</ConnectionString>
	</Server>
  </Servers>
  <Clients>
	<Client path="c:\program files (x86)\werbas\werbasweb\client">
	  <TSClient>false</TSClient>
	</Client>
	<Client path="c:\program files (x86)\werbas\werbasweb\clientNightly">
	  <TSClient>false</TSClient>
	</Client>
  </Clients>
</Config>
```

## XSD

``` xml
<xs:schema attributeFormDefault="unqualified" elementFormDefault="qualified" xmlns:xs="http://www.w3.org/2001/XMLSchema">
  <xs:element name="Config">
    <xs:complexType>
      <xs:sequence>
        <xs:element name="Servers">
          <xs:complexType>
            <xs:sequence>
              <xs:element name="Server" maxOccurs="unbounded" minOccurs="0">
                <xs:complexType>
                  <xs:sequence>
                    <xs:element type="xs:string" name="ConnectionString"/>
                  </xs:sequence>
                  <xs:attribute type="xs:string" name="path" use="required"/>
                </xs:complexType>
              </xs:element>
            </xs:sequence>
          </xs:complexType>
        </xs:element>
        <xs:element name="Clients">
          <xs:complexType>
            <xs:sequence>
              <xs:element name="Client" maxOccurs="unbounded" minOccurs="0">
                <xs:complexType>
                  <xs:sequence>
                    <xs:element type="xs:string" name="TSClient"/>
                  </xs:sequence>
                  <xs:attribute type="xs:string" name="path" use="required"/>
                </xs:complexType>
              </xs:element>
            </xs:sequence>
          </xs:complexType>
        </xs:element>
      </xs:sequence>
    </xs:complexType>
  </xs:element>
</xs:schema>
```
