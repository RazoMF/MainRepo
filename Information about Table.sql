/*Выводим всю информацию о нужной табличке. В том числе названиия полей и их тип.*/
SELECT table_name, column_name, data_type, data_length
FROM all_tab_columns--USER_TAB_COLUMNS
WHERE lower(table_name) = 'table_name';