/*������� ���� ������� � �������� ������� ����� ��� ������ �������������*/

Grant select on scheme1.tab1 to scheme2; /*���� ����� �� SELECT �� ������� TAB1*/
Grant insert, update, delete on scheme1.tab1 to scheme2; /*���� ����� �� insert, update, delete ������� TAB1*/
Revoke insert, update, delete on scheme1.tab1 from scheme2; /*������� ����� �� insert, update, delete ������� TAB1*/
Grant alter on scheme1.tab1 to scheme2; /*���� ����� �� alter ������� TAB1*/
Grant all on scheme1.tab1 to scheme2; /*���� ��� ����� �� ������� TAB1*/
Grant execute on scheme1.pkg1 to scheme2; /*���� ����� �� ���������� PKG1*/
Grant create database link to scheme2; /*���� ����� �� �������� ������ �� �����*/

