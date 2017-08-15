CREATE DEFINER=`root`@`localhost` PROCEDURE `get_items`()
BEGIN
	select name from sales.items;
END